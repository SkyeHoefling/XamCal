using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace EarnieJr.Controls
{
    public partial class Calendar : ContentView
    {
        public int Year
        {
            get { return (int)GetValue(YearProperty); }
            set { SetValue(YearProperty, value); }
        }

        public static readonly BindableProperty YearProperty = BindableProperty.Create(
            nameof(Year),
            typeof(int),
            typeof(Calendar),
            0,
            BindingMode.TwoWay,
            propertyChanged: OnYearPropertyChanged);

        private static void OnYearPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var context = (Calendar)bindable;
            if (context != null)
            {
                context.Year = (int)newValue;
                context.Redraw();
            }
        }

        public int Month
        {
            get { return (int)GetValue(MonthProperty); }
            set { SetValue(MonthProperty, value); }
        }

        public static readonly BindableProperty MonthProperty = BindableProperty.Create(
            nameof(Month),
            typeof(int),
            typeof(Calendar),
            0,
            BindingMode.TwoWay,
            propertyChanged: OnMonthPropertyChanged);

        private static void OnMonthPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var context = (Calendar)bindable;
            if (context != null)
            {
                context.Month = (int)newValue;
                context.Redraw();
            }
        }

        public IEnumerable<Event> Events
        {
            get { return (IEnumerable<Event>)GetValue(EventsProperty); }
            set { SetValue(EventsProperty, value); }
        }

        public static readonly BindableProperty EventsProperty = BindableProperty.Create(
            nameof(Events),
            typeof(IEnumerable<Event>),     
            typeof(Calendar),
            null,
            propertyChanged: OnEventsPropertyChanged);

        private static void OnEventsPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var context = (Calendar)bindable;
            if (context != null)
            {
                context.Events = (IEnumerable<Event>)newValue;
                context.Redraw();

                if (context.Events is ObservableCollection<Event>)
                {
                    var events = (ObservableCollection<Event>)context.Events;
                    events.CollectionChanged += (s, e) => context.Redraw();
                }
            }
        }

        public DataTemplate DayTemplate
        {
            get { return (DataTemplate)GetValue(DayTemplateProperty); }
            set { SetValue(DayTemplateProperty, value); }
        }

        public static readonly BindableProperty DayTemplateProperty = BindableProperty.Create(
            nameof(DayTemplate),
            typeof(DataTemplate),
            typeof(Calendar),
            null,
            propertyChanged: OnItemTemplatePropertyChanged);

        private static void OnItemTemplatePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var context = (Calendar)bindable;
            if (context != null)
            {
                context.DayTemplate = (DataTemplate)newValue;
                context.Redraw();
            }
        }

        public ICommand DaySelected
        {
            get { return (ICommand)GetValue(DaySelectedProperty); }
            set { SetValue(DaySelectedProperty, value); }
        }

        public static readonly BindableProperty DaySelectedProperty = BindableProperty.Create(
            nameof(DaySelected),
            typeof(ICommand),
            typeof(Calendar),
            null,
            propertyChanged: OnDaySelectedPropertyChanged);

        private static void OnDaySelectedPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var context = (Calendar)bindable;
            if (context != null)
            {
                context.DaySelected = (ICommand)newValue;
            }
        }
    }
}
