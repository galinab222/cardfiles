﻿using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardFiles.Models;
using CardFiles.Views;
namespace CardFiles.Classes
{
    public class ShowerVisits
    {
        public static int acceptChanges;
        public static void Show(VisitsViewModel model)
        {
            VisitsControl control = new VisitsControl() { DataContext = model };
            if (control != null)
            {
                Window wnd = new Window
                {
                    HorizontalAlignment = HorizontalAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Top,
                    SizeToContent=SizeToContent.WidthAndHeight,
                    WindowStartupLocation = WindowStartupLocation.CenterScreen,
                   // ResizeMode = ResizeMode.NoResize
                };
            
               

                Grid newGrid = new Grid()
                {
                    HorizontalAlignment=HorizontalAlignment.Stretch,
                    VerticalAlignment=VerticalAlignment.Stretch
                };
            
                RowDefinition R1 = new RowDefinition();
                R1.Height = new GridLength(12, GridUnitType.Star);
                newGrid.RowDefinitions.Add(R1);
                RowDefinition R2 = new RowDefinition();
                R2.Height = new GridLength(50);
                newGrid.RowDefinitions.Add(R2);
                RowDefinition R3 = new RowDefinition();
                R3.Height = new GridLength(50);

                newGrid.RowDefinitions.Add(R3);
                wnd.Content = newGrid;

                Grid.SetRow(control, 0);
                newGrid.Children.Add(control);


                // Панель для двух кнопок
                Grid buttonGrid = new Grid()
                {
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch
                };

                ColumnDefinition C1 = new ColumnDefinition();
                 C1.Width = new GridLength(1, GridUnitType.Star);
                buttonGrid.ColumnDefinitions.Add(C1);
                ColumnDefinition C2 = new ColumnDefinition();
                C2.Width = new GridLength(2, GridUnitType.Star);
                buttonGrid.ColumnDefinitions.Add(C2);
                ColumnDefinition C3 = new ColumnDefinition();
                C3.Width = new GridLength(1, GridUnitType.Star);
                buttonGrid.ColumnDefinitions.Add(C3);

                Grid.SetRow(buttonGrid, 1);
                newGrid.Children.Add(buttonGrid);
               
                // кнопка отказа
                Button closeButton = new Button                {
                    Content = "Отказаться от изменений и закрыть",
                     HorizontalAlignment = HorizontalAlignment.Right,
                     Width =200,
                     Height = 35,
                 VerticalAlignment = VerticalAlignment.Top
                };
                   closeButton.Click += (s, e) => {
                       model.UnDoChanges();
                    wnd.Close(); };
                Grid.SetColumn(closeButton, 0);
                buttonGrid.Children.Add(closeButton);
                // кнопка сохранения
                Button applyButton = new Button
                {
                    Content = "Сохранить и закрыть",
                    HorizontalAlignment=HorizontalAlignment.Left,
                    Width=200,
                    Height=35,
                    VerticalAlignment=VerticalAlignment.Top
                };
                applyButton.Click += (s, e) => {
                    acceptChanges = 1;
                    model.Save();
                    wnd.Close(); };
                Grid.SetColumn(applyButton, 2);
                buttonGrid.Children.Add(applyButton);
              

                wnd.Closed += (s, e) => wnd.Close();
                wnd.ShowDialog();

            }
        }
    }
}
