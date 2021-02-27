using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace WilliamsGameOfPig.Models.Extensions
{
	/// <summary>
	/// Extensions method for an ISession object.
	///
	/// Author: Nolan Williams
	/// Date:	2/26/2021
	/// </summary>
	public static class SessionExtensions
	{

		/// <summary>
		/// Serializes and sets the object of the specified type [T]
		/// in the [session] with specified [key].
		/// </summary>
		/// <typeparam name="T">The type of object.</typeparam>
		/// <param name="session">The session.</param>
		/// <param name="key">The key.</param>
		/// <param name="value">The value.</param>
		public static void SetObject<T>(this ISession session, string key, T value)
		{
			session.SetString(key, JsonConvert.SerializeObject(value));
		}

		/// <summary>
		/// Deserializes and gets the object of the specified type [T]
		/// in the [session] with the specified [key].
		/// </summary>
		/// <typeparam name="T">The type of object.</typeparam>
		/// <param name="session">The session.</param>
		/// <param name="key">The key.</param>
		/// <returns>The object of the specified type [T].</returns>
		public static T GetObject<T>(this ISession session, string key)
		{
			var valueJson = session.GetString(key);
			return string.IsNullOrEmpty(valueJson) ? default : JsonConvert.DeserializeObject<T>(valueJson);
		}
	}
}
