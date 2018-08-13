using Serverless.Domain.News;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Serverless.Application.UseCaseSharedModels
{
	[XmlRoot("headlines")]	
	public class NewsStatesContainerModel
	{				
		[XmlElement("news")]
		public List<NewsStatesModel> NewsStatesModels { get; set; }
	}

	[XmlType("news")]
	public class NewsStatesModel
    {
		public NewsStatesModel() {

		}

		public NewsStatesModel(NewsStates newsState)
		{
			if (newsState == null) throw new ArgumentNullException(nameof(newsState));

			Id = newsState.Id;
			Status = newsState.Status;
			NewsContentId = newsState.NewsContentId;
		}

		[XmlAttribute("id")]
		public int Id { get; set; }		

		[XmlAttribute("contents_id")]
		public int NewsContentId { get; set; }

		[XmlAttribute("status")]
		public string Status { get; set; }
	}
}
