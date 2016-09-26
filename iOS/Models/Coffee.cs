﻿namespace HookMeUP.iOS
{
	public class Coffee
	{
		public Coffee(string title, string imageName, string price/*, bool available = false, bool selected = false*/)
		{
			Title = title;
			ImageName = imageName;
			Price = price;
			//Available = available;
			//Selected = selected;
		}

		public string Title { get; private set; }
		public string ImageName { get; private set; }
		public string Price { get; private set; }
		//public bool Available;
		//public bool Selected;
	}
}

