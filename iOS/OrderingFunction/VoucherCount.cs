﻿using System;

namespace HookMeUP.iOS
{
	class VoucherCount
	{

		public bool IsVoucherDepleted
		{
			get;
			private set;
		}

		public int Voucher
		{
			get;
			set;
		}

		public double Price
		{
			get;
			set;
		}

		public bool IsSelected
		{
			get;
			set;
		}

		public bool IsDeselected
		{
			get;
			set;
		}

		public bool HasTag
		{
			get;
			set;
		}

		public bool Commited
		{
			get;
			set;
		}

		public int GetUncommitedVouchers
		{
			get;
			private set;
		}

		public void VoucherChange()
		{
			if (Voucher > 0) IsVoucherDepleted = false;
			else IsVoucherDepleted = true;
			
			if (IsSelected && !IsVoucherDepleted) --Voucher;
			if (IsDeselected) ++Voucher;
		}

		public int GetVoucher()
		{
			return Voucher;
		}
	}

	class TagOrder
	{
		public string OrderName
		{
			get;
			private set;
		}

		public TagOrder(string orderName)
		{
			OrderName = orderName;
				
		}

	}
}

