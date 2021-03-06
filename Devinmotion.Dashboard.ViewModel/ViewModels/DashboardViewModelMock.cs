﻿using System;
using System.Collections.ObjectModel;
using Devinmotion.Dashboard.Model.Models;
using Devinmotion.Dashboard.Model.Services;

namespace Devinmotion.Dashboard.ViewModel.ViewModels
{
    public class DashboardViewModelMock : IDashboardViewModel
    {
        public WeatherInfo CurrentWeatherInfo { get; }

        public DateTime Now { get; }

        public ReadOnlyObservableCollection<AppointmentBase> Appointments { get; }

        public Birthday CurrentBirthday { get; }

        public DashboardViewModelMock()
        {
            WeatherConditionService weatherConditionService = new WeatherConditionService();
            WeatherCondition weatherCondition = weatherConditionService.ConvertKeyToWeatherCondition("03n");

            CurrentWeatherInfo =
                new WeatherInfo(
                    "Köln",
                    "21°C",
                    "bewölkt",
                    weatherCondition);

            Now = DateTime.Now;

            ObservableCollection<AppointmentBase> appointments = new ObservableCollection<AppointmentBase>();
            appointments.Add(
                new Appointment(
                    DateTime.Today.AddHours(9), 
                    DateTime.Today.AddHours(17), 
                    "Workshop 'Clean Code Developer'", 
                    "Stefan Lieser", 
                    "Chiang Mai"));
            appointments.Add(
                new Birthday(
                    new DateTime(2016, 7, 18),
                    "Karl Coder"));
            appointments.Add(
                new Appointment(
                    new DateTime(2016, 7, 19, 8, 0, 0),
                    new DateTime(2016, 7, 19, 16, 0, 0),
                    "Workshop 'Refactoring Legacy Code'",
                    "Stefan Lieser",
                    "Shanghai"));
            Appointments = new ReadOnlyObservableCollection<AppointmentBase>(appointments);

            CurrentBirthday =
                new Birthday(
                    DateTime.Today,
                    "Peter Müller");
        }
    }
}
