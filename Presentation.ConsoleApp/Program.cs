using System;
using Logistics.Domain;
using Logistics.Domain.Model;
using Logistics.Infrastructure;
using System.Linq;
using Logistics.ObjectMothers;
using System.Collections.Generic;
using System.Diagnostics;
using NHibernate;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace Presentation.ConsoleApp
{
	class MainClass
	{

		public static void Main (string[] args)
		{
			var input = Console.ReadKey();
			while(input.Key != ConsoleKey.Q)
			{
				switch (input.Key) 
				{

				case ConsoleKey.D1:
					LazyAndNotLazyExample.Run ();
					break;

				case ConsoleKey.D2:
					StatelessSessionExample.Run ();
					break;

				case ConsoleKey.D3:
					EnterpriseLibraryValidationExample.Run ();
					break;

					default:
					break;
				}

				input = Console.ReadKey ();
			}
		}
	}
}
