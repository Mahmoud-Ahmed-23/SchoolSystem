using Microsoft.Extensions.Localization;
using SchoolSystem.Application._SharedResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Application.Bases
{
	public class ResponseHandler
	{
		private readonly IStringLocalizer<SharedResources> _localizer;

		public ResponseHandler(IStringLocalizer<SharedResources> localizer)
		{
			_localizer = localizer;
		}
		public Response<T> Deleted<T>(string Message = null!)
		{


			return new Response<T>()
			{
				StatusCode = System.Net.HttpStatusCode.OK,
				Succeeded = true,
				Message = Message == null ? _localizer[SharedResourcesKeys.Deleted] : Message
			};
		}
		public Response<T> Success<T>(T entity, string message = null!, object Meta = null!)
		{
			return new Response<T>()
			{
				Data = entity,
				StatusCode = System.Net.HttpStatusCode.OK,
				Succeeded = true,
				Message = message == null ? _localizer[SharedResourcesKeys.Success] : message,
				Meta = Meta
			};
		}
		public Response<T> Unauthorized<T>(string Message = null!)
		{

			return new Response<T>()
			{
				StatusCode = System.Net.HttpStatusCode.Unauthorized,
				Succeeded = true,
				Message = Message == null ? _localizer[SharedResourcesKeys.Unauthorized] : Message
			};

		}
		public Response<T> BadRequest<T>(string Message = null!)
		{
			return new Response<T>()
			{
				StatusCode = System.Net.HttpStatusCode.BadRequest,
				Succeeded = false,
				Message = Message == null ? _localizer[SharedResourcesKeys.BadRequest] : Message
			};
		}
		public Response<T> UnprocessableEntity<T>(string Message = null!)
		{
			return new Response<T>()
			{
				StatusCode = System.Net.HttpStatusCode.UnprocessableEntity,
				Succeeded = false,
				Message = Message == null ? "Unprocessable Entity" : Message
			};
		}

		public Response<T> NotFound<T>(string message = null!)
		{
			return new Response<T>()
			{
				StatusCode = System.Net.HttpStatusCode.NotFound,
				Succeeded = false,
				Message = message == null ? _localizer[SharedResourcesKeys.NotFound] : message
			};
		}

		public Response<T> Created<T>(T entity, string message = null!, object Meta = null!)
		{
			return new Response<T>()
			{
				Data = entity,
				StatusCode = System.Net.HttpStatusCode.Created,
				Succeeded = true,
				Message = message == null ? _localizer[SharedResourcesKeys.Created] : message,
				Meta = Meta
			};
		}
	}
}
