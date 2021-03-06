﻿using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;

namespace TestApplication
{
	/// <summary>
	/// Interaction logic for TouchablePanelTest.xaml
	/// </summary>
	public partial class TouchablePanelTest
	{
		public ObservableCollection<string> Pictures { get; private set; }

		public TouchablePanelTest()
		{
			Pictures = new ObservableCollection<string>();
			string picturesPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
			string[] pictures = Directory.GetFiles(picturesPath, "*.jpg");
			foreach (string file in pictures.Take(5))
				Pictures.Add(file);

			DataContext = this;
			InitializeComponent();
		}
	}
}
