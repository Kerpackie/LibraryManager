namespace LibraryManager.Controls.BookFormControls
{
	public static class SubjectControls
	{
		public static ListBox CreateListBoxBookSubjectsViewMode()
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
		
		public static Control[] CreateBookSubjectControlsEditMode()
		{
			var listBoxAllSubjects = CreateListBoxAllSubjectsEditMode();
			var listBoxBookSubjects = CreateListBoxBookSubjectsEditMode();
			var buttonAddSubject = CreateButtonAddSubjectEditMode();
			var buttonRemoveSubject = CreateButtonRemoveSubjectEditMode();

			return new Control[]
			{
				listBoxAllSubjects,
				listBoxBookSubjects,
				buttonAddSubject,
				buttonRemoveSubject
			};
		}
		
		private static ListBox CreateListBoxAllSubjectsEditMode()
		{
			var listBoxAllSubjects = new ListBox
			{
				Font = new System.Drawing.Font(
					"Microsoft Sans Serif", 
					12F,
					System.Drawing.FontStyle.Regular, 
					System.Drawing.GraphicsUnit.Point, 
					((byte) (0))),
				FormattingEnabled = true,
				ItemHeight = 20,
				Location = new System.Drawing.Point(58, 190),
				Name = "listBoxAllSubjects",
				Size = new System.Drawing.Size(152, 124)
			};

			return listBoxAllSubjects;
		}

		private static ListBox CreateListBoxBookSubjectsEditMode()
		{
			var listBoxBookSubjects = new ListBox
			{
				Font = new System.Drawing.Font(
					"Microsoft Sans Serif",
					12F,
					System.Drawing.FontStyle.Regular,
					System.Drawing.GraphicsUnit.Point, 
					((byte) (0))),
				FormattingEnabled = true,
				ItemHeight = 20,
				Location = new System.Drawing.Point(271, 190),
				Name = "listBoxBookSubjects",
				Size = new System.Drawing.Size(153, 124)
			};

			return listBoxBookSubjects;
		}
		
		private static Button CreateButtonAddSubjectEditMode()
		{
			var buttonAddSubject = new Button
			{
				Font = new System.Drawing.Font(
					"Microsoft Sans Serif", 
					12F, 
					System.Drawing.FontStyle.Regular, 
					System.Drawing.GraphicsUnit.Point,
					((byte) (0))),
				Location = new System.Drawing.Point(216, 206),
				Name = "btnAddSubjectToBook",
				Size = new System.Drawing.Size(49, 46),
				TabIndex = 29,
				Text = ">>",
				UseVisualStyleBackColor = true
			};

			return buttonAddSubject;
		}
		
		private static Button CreateButtonRemoveSubjectEditMode()
		{
			var buttonRemoveSubject = new Button
			{
				Font = new System.Drawing.Font(
					"Microsoft Sans Serif", 
					12F,
					System.Drawing.FontStyle.Regular,
					System.Drawing.GraphicsUnit.Point,
					((byte) (0))),
				Location = new System.Drawing.Point(216, 258),
				Name = "btnRemoveSubjectFromBook",
				Size = new System.Drawing.Size(49, 46),
				TabIndex = 28,
				Text = "<<",
				UseVisualStyleBackColor = true
			};

			return buttonRemoveSubject;
		}
	}
}