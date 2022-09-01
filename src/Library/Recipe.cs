//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }
        }
        public double Costoinsumos () //metodo para calcular la sumatoria de los costos de los productos
        {
            double costoinsumos=0;
            foreach (Step step in this.steps)
            {

            costoinsumos = costoinsumos + step.Input.UnitCost;
            
            }
            Console.WriteLine($"El costo de los insumos fue de: {costoinsumos} ");
            return costoinsumos;
        }
 //Costo equipamiento = Sumatoria de tiempo de uso 
        //                     x costo/hora del equipo para todos los pasos de la receta
        //Asumo que el tiempo esta en segundos
        public double Costoequip() 
        {
            double costoequip=0;
             foreach (Step step in this.steps)
            {
            double segundos = step.Time;
            double divisor = 3600;
            double horas = segundos/divisor;
            costoequip = costoequip + (step.Equipment.HourlyCost*horas);
            
            }
            Console.WriteLine($"El costo del equipamiento fue de: {costoequip} ");
            return costoequip;

        }

        public void GetProductionCost(double costoinsumos, double costoequip)
        {
            double Costototal = costoequip + costoinsumos ;
            Console.WriteLine($"El costo total fue de : {Costototal}");
            
        }


        
    }
}