using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace XamCal.Abstractions
{
    public partial class Calendar : ContentView
    {
        private Grid _grid;
        public Calendar()
        {
            HorizontalOptions = new LayoutOptions(LayoutAlignment.Fill, true);
            VerticalOptions = new LayoutOptions(LayoutAlignment.Fill, true);

            _grid = new Grid();
            var rowCount = 6;
            var columnCount = 7;

            for (int i = 0; i < rowCount; i++)
            {
                _grid.RowDefinitions.Add(new RowDefinition
                {
                    Height = GridLength.Star
                });
            }

            for (int i = 0; i < columnCount; i++)
            {
                _grid.ColumnDefinitions.Add(new ColumnDefinition
                {
                    Width = GridLength.Star
                });
            }

            Content = _grid;
        }

        private void Redraw()
        {
            if (Year <= 0 || Month <= 0 || DayTemplate == null) return;

            var daysInMonth = DateTime.DaysInMonth(Year, Month);
            _grid.Children.Clear();

            var row = 0;
            for (int day = 0; day < daysInMonth; day++)
            {
                var date = new DateTime(Year, Month, day + 1);
                var events = GetEvents(date);
                var view = CreateView(new Day(date, events));

                var column = (int)date.DayOfWeek;
                if (day > 0 && date.DayOfWeek == DayOfWeek.Sunday)
                {
                    row++;
                }

                _grid.Children.Add(view, column, row);
            }
        }

        private View CreateView(Day day)
        {
            var view = (View)DayTemplate.CreateContent();
            view.BindingContext = day;
            view.GestureRecognizers.Add(BuildTapGesture(day));
            return view;
        }

        private TapGestureRecognizer BuildTapGesture(Day day)
        {
            var tapGesture = new TapGestureRecognizer();
            tapGesture.Command = DaySelected;
            tapGesture.CommandParameter = day;

            return tapGesture;
        }

        private IEnumerable<Event> GetEvents(DateTime current)
        {
            return Events?.Where(x => x.Date.Date == current.Date);
        }
    }
}

