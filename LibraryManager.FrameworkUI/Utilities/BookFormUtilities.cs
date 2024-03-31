using System.Windows.Forms;

namespace LibraryManager.FrameworkUI.Utilities
{
	public static class BookFormUtilities
	{
		public static ListBox CreateListBoxSubjects()
		{
			var listBoxSubjects = new ListBox
			{
				Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
				ItemHeight = 20,
				Location = new System.Drawing.Point(58, 190),
				Name = "listBoxSubjects",
				Size = new System.Drawing.Size(366, 124)
			};

			return listBoxSubjects;
		}
		
		public static ListBox CreateListBoxCollections()
		{
			var listBoxCollections = new ListBox
			{
				Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
				ItemHeight = 20,
				Location = new System.Drawing.Point(463, 190),
				Name = "listBoxCollections",
				Size = new System.Drawing.Size(366, 124)
			};

			return listBoxCollections;
		}
		
		public static ListBox CreateListBoxAllCollections()
		{
			var listBoxAllCollections = new ListBox
			{
				Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0))),
				FormattingEnabled = true,
				ItemHeight = 20,
				Location = new System.Drawing.Point(486, 190),
				Name = "listBoxAllCollections",
				Size = new System.Drawing.Size(366, 124)
			};

			return listBoxAllCollections;
		}
		
		public static ListBox CreateListBoxBookCollections()
		{
			var listBoxBookCollections = new ListBox
			{
				Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0))),
				FormattingEnabled = true,
				ItemHeight = 20,
				Location = new System.Drawing.Point(58, 190),
				Name = "listBoxBookCollections",
				Size = new System.Drawing.Size(366, 124)
			};

			return listBoxBookCollections;
		}
		
		public static Button CreateButtonAddCollection()
		{
			var buttonAddCollection = new Button
			{
				Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0))),
				Location = new System.Drawing.Point(432, 190),
				Name = "buttonAddCollection",
				Size = new System.Drawing.Size(48, 30),
				Text = ">>"
			};

			return buttonAddCollection;
		}
		
		public static Button CreateButtonRemoveCollection()
		{
			var buttonRemoveCollection = new Button
			{
				Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0))),
				Location = new System.Drawing.Point(432, 226),
				Name = "buttonRemoveCollection",
				Size = new System.Drawing.Size(48, 30),
				Text = "<<"
			};

			return buttonRemoveCollection;
		}
	}
}