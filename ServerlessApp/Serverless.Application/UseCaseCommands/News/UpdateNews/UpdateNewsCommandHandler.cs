﻿using Serverless.Application.Persistence;
using Serverless.Application.UseCaseSharedModels;
using Serverless.Domain.News;
using System;

namespace Serverless.Application.UseCaseCommands.News
{
	public class UpdateNewsCommandHandler : IUpdateNewsCommandHandler
	{
		private readonly INewsContentRepository _newsContentRepository;

		public UpdateNewsCommandHandler(
			INewsContentRepository newsContentRepository)
		{
			_newsContentRepository = newsContentRepository;
		}

		public NewsContentModel Execute(UpdateNewsCommand command)
		{
			var now = DateTime.Now;
			var newsContent = new NewsContent
			{
				Id = command.Id,
				Date = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0),
				Time = new DateTime(1900, 1, 1, now.Hour, now.Minute, now.Second),

				CountryName = command.CountryName,
				Title = command.Title,
				Supplementation = command.Supplementation,
				Important = command.Important,
				ImportantLevel = command.ImportantLevel,
				Ratio = command.Ratio,
				Unit = command.Unit,
				Period = command.Period,
				Expectation = command.Expectation,
				Result = command.Result,
				LastTime = command.LastTime,
				Correction = command.Correction,
				Uid = command.Uid
			};

			_newsContentRepository.Update(newsContent);

			return new NewsContentModel(newsContent);
		}

	}
}
