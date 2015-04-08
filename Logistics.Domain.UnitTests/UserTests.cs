using NUnit.Framework;
using System;
using Logistics.ObjectMothers;
using Logistics.Domain.Model;

namespace Logistics.Domain.UnitTests
{
	[TestFixture ()]
	public class UserTests
	{
		[Test ()]
		public void CheckForMonkeyInEmail ()
		{
			var user = UserObjectMother.CreateNewAdmin();

			StringAssert.Contains("@", user.Email);
		}
			
		[Test ()]
		public void CheckForCorrectEmail ()
		{
			var user = UserObjectMother.CreateNewAdmin();

			StringAssert.IsMatch( @"^.+@.+$" , user.Email );
		}


		[Test ()]
		public void CheckForCorrectLenghtOfPassword ()
		{
			var user = UserObjectMother.CreateNewAdmin();

			Assert.Greater(user.Login.Length,3);
		}

		[Test ()]
		public void CheckForNewAdminRole ()
		{
			var user = UserObjectMother.CreateNewAdmin();

			Assert.IsTrue(user.Role != Role.CLIENT && user.Role != Role.DRIVER);
		}

		[Test ()]
		public void CheckForNewClientRole ()
		{
			var user = UserObjectMother.CreateNewAdmin();
			user.Role = Role.DRIVER;
			Assert.AreEqual(user.Role, Role.DRIVER);
		}
	}
}

