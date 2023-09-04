﻿using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerEnumerate.Entities.Enums;

namespace WorkerEnumerate.Entities
    {
    internal class Worker
        {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Department Department{ get; set; }
        public List<HourContract> Contracts { get;set; } = new List<HourContract>();
        public Worker() { }
        public Worker(string name, WorkerLevel level, double baseSalary, Department department)
            {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddContract(HourContract contract)
            {
            Contracts.Add(contract);
            }
        public void RemoveContract(HourContract contract)
            {
            Contracts.Remove(contract);
            }
        public double Income(int year, int month)
            {
            double income = BaseSalary;
                foreach (HourContract contract in Contracts)
                {
                if (contract.Date.Year == year && contract.Date.Month == month)
                    {
                    income = income + contract.totalValue();
                    }
                }
                return income;
            }
    }
    }
