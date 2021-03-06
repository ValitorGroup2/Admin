﻿using AdminWeb.DAL.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminWeb.DAL
{
	public class AccountDal : IAccountDal, IDisposable
	{
		#region Initialize
		private AccountDataContext accountContext;
		private AdminWebDalDataContext adminWebContext;

		public AccountDal(AccountDataContext accountContext, AdminWebDalDataContext adminWebContext)
		{
			this.accountContext = accountContext;
			this.adminWebContext = adminWebContext;
		}
		#endregion

		/// <summary>
		/// Function that returns AspNetUser by name
		/// </summary>
		/// <param name="userName"></param>
		/// <returns>AspNetUser</returns>
		public AspNetUser GetUserByName(string userName)
		{
			AspNetUser user = accountContext.AspNetUsers.Where(u => u.UserName == userName).SingleOrDefault();

			return user;
		}

		/// <summary>
		/// Function that updates user information
		/// </summary>
		/// <param name="company"></param>
		public void EditUserInfo(Company company)
		{
			Company tempCompany = adminWebContext.Companies.Where(c => c.ID == company.ID).SingleOrDefault();

			tempCompany.Address = company.Address;
			tempCompany.BankAccount = company.BankAccount;
			tempCompany.City = company.City;
			tempCompany.Email = company.Email;
			tempCompany.Name = company.Name;
			tempCompany.Phone = company.Phone;
			tempCompany.SSN = company.SSN;
			tempCompany.ZipCode = company.ZipCode;
			tempCompany.AcceptedTerms = true;

			adminWebContext.SubmitChanges();
		}

		/// <summary>
		/// Function that returns true if user has been verified, else false.
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Bool</returns>
		public bool IsVerified(int id)
		{
			string userID = Convert.ToString(id);
			var user = accountContext.AspNetUsers.Where(u => u.Id == userID).SingleOrDefault();

			if (user.Verified == true)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// Function that verifies user and returns his company
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Company</returns>
		public Company VerifyUserByCompanyID(int id)
		{
			AspNetUser user = accountContext.AspNetUsers.Where(u => u.CompanyID == id).SingleOrDefault();

			user.Verified = true;

			accountContext.SubmitChanges();

			Company company = adminWebContext.Companies.Where(c => c.ID == id).SingleOrDefault();

			return company;
		}

		/// <summary>
		/// Function that returns User by his id
		/// </summary>
		/// <param name="id"></param>
		/// <returns>AspNetUser</returns>
		public AspNetUser GetUserByID(string id)
		{
			AspNetUser user = accountContext.AspNetUsers.Where(u => u.Id == id).SingleOrDefault();

			return user;
		}

		/// <summary>
		/// Function that gets user by CompanyID and returns found user
		/// </summary>
		/// <param name="id"></param>
		/// <returns>AspNetUser</returns>
		public AspNetUser GetUserCompanyID(int id)
		{
			AspNetUser user = accountContext.AspNetUsers.Where(u => u.CompanyID == id).SingleOrDefault();

			return user;
		}

		#region Dispose
		private bool disposed = false;

		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					accountContext.Dispose();
				}
			}
			this.disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		#endregion
	}
}