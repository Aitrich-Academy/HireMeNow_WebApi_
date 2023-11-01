﻿using AutoMapper;
using Domain.Models;
using Domain.Service.JobProvider.Dtos;
using Domain.Service.JobProvider.Interfaces;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;
using Domain.Helpers;
using HireMeNow_WebApi.Helpers;
using SendGrid.Helpers.Mail;

namespace Domain.Service.JobProvider
{
	public class InterviewRepository:IInterviewRepository
	{
		DbHireMeNowWebApiContext context;
		public IMapper mapper { get; set; }

		public InterviewRepository(DbHireMeNowWebApiContext context,IMapper _mapper)
		{
			this.context = context;
			mapper= _mapper;
		}

		public Interview shduleInterview(InterviewsheduleDtos interview, CompanyUser user)

		{
			try
			{
				JobApplication applicaction = context.JobApplications.Where(a => a.Id == interview.ApplicationId).Include(e => e.JobPost).FirstOrDefault();
				var interviewtoshedule = mapper.Map<Interview>(interview);
				interviewtoshedule.JobId = applicaction.JobPost_id;
				interviewtoshedule.ApplicationId = applicaction.Id;
				interviewtoshedule.Status = JobInterviewStatus.SCHEDULED;
				interviewtoshedule.SheduledBy = user.Id;
				interviewtoshedule.interviewee = applicaction.Applicant;
				interviewtoshedule.CompanyId = (Guid)user.Company;


				context.Interviews.AddAsync(interviewtoshedule);
				context.SaveChanges();
				return interviewtoshedule;

			}
			catch (Exception ex)
			{
				throw ex;
			}


		}
		public async Task<PagedList<Interview>> sheduledInterviewList(Guid companyid, InterviewParams param)
		{
			var query = context.Interviews
			   .OrderByDescending(c => c.Date).Where(e=>e.CompanyId==companyid).Include(e=>e.Job).Include(e=>e.Jobseeker).Include(e=>e.Application).Include(e=>e.Company).Include(e=>e.CompanyUser)
			   .AsQueryable();
			return await PagedList<Interview>.CreateAsync(query,
					param.PageNumber, param.PageSize);


		}
		public bool removeInterview(Guid id)
		{
			Interview interview = context.Interviews.FirstOrDefault(e => e.Id == id);
			if (interview != null)
			{
				context.Interviews.Remove(interview);
				context.SaveChanges();
				return true;
			}
			else
			{
				return false;
			}

		}
	}
}
