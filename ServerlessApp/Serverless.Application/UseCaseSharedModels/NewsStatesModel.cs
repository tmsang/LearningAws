using Serverless.Domain.News;
using System;

namespace Serverless.Application.UseCaseSharedModels
{
	public class NewsStatesModel
    {
		public NewsStatesModel(NewsStates newsState)
		{
			if (newsState == null) throw new ArgumentNullException(nameof(newsState));

			Id = newsState.Id;
			Code = newsState.Status;
			NewsContentId = newsState.NewsContentId;
		}

		public int Id { get; set; }
		public string Code { get; set; }
		public int NewsContentId { get; set; }
	}
}
