using System;
using System.Collections.Generic;
using System.Text;

namespace Lab11
{
    class ServiceStation
    {
        public delegate void Service(Car carInService);
        public void set_IsCorrectWheelAngles(Car car) => car.IsCorrectWheelAngles = true;
        public void set_IsPainted(Car car) => car.IsPainted = true;
        public void set_IsOilChanged(Car car) => car.IsOilChanged = true;
        public void set_IsFullRevision(Car car) => car.IsFullRevision = true;
        public void set_IsWheelReplaced(Car car) => car.IsWheelReplaced = true;
        public void set_IsCarBodyRepaired(Car car) => car.IsCarBodyRepaired = true;
    }
}