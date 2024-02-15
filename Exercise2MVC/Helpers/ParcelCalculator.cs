using Exercise2MVC.Models.Entities;
using Exercise2MVC.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise2MVC.Helpers
{
    public static class ParcelCalculator
    {
        public static ParcelCalculatorResponse CalculateClassificationAndCost(decimal weight)
        {
            string classification = GetClassification(weight);
            decimal cost = CalculateCost(classification, weight);

            return new ParcelCalculatorResponse()
            {
                Classification = GetClassification(weight),
                Cost = CalculateCost(classification, weight)
            };
        }

        public static ParcelCalculatorResponse CalculateClassificationAndTotalCost(List<ParcelItem> parcelItems)
        {
            decimal totalWeight = parcelItems.Select(s => s.Weight).Sum();
            decimal totalCost = 0;

            foreach (ParcelItem parcelItem in parcelItems)
            {
                string classification = GetClassification(parcelItem.Weight);
                decimal cost = CalculateCost(classification, parcelItem.Weight);
                totalCost = totalCost + cost;
            }

            if (totalWeight == 0)
            {
                return new ParcelCalculatorResponse()
                {
                    Classification = "None",
                    Cost = totalCost
                };
            }
            else if (totalWeight <= 10)
            {
                return new ParcelCalculatorResponse()
                {
                    Classification = "Small",
                    Cost = 10
                };
            }
            else if (totalWeight <= 20)
            {
                return new ParcelCalculatorResponse()
                {
                    Classification = "Medium",
                    Cost = totalCost
                };
            }
            else if (totalWeight <= 30)
            {
                return new ParcelCalculatorResponse()
                {
                    Classification = "Large",
                    Cost = totalCost
                };
            }
            else if (totalWeight <= 50)
            {
                return new ParcelCalculatorResponse()
                {
                    Classification = "Heavy",
                    Cost = totalCost
                };
            }
            else
            {
                return new ParcelCalculatorResponse()
                {
                    Classification = "Reject",
                    Cost = totalWeight
                };
            }
        }

        private static string GetClassification(decimal weight)
        {
            if (weight == 0)
            {
                return "None";
            }
            else if (weight <= 10)
            {
                return "Small";
            }
            else if (weight <= 20)
            {
                return "Medium";
            }
            else if (weight <= 30)
            {
                return "Large";
            }
            else if (weight <= 50)
            {
                return "Heavy";
            }
            else
            {
                return "Reject";
            }
        }

        private static decimal CalculateCost(string classification, decimal weight)
        {
            switch (classification)
            {
                case "None":
                    return 0; // N/A for 0kg

                case "Small":
                    return 10; // Flat rate for small parcels

                case "Medium":
                    return 5 * weight; // $5 * Weight for medium parcels

                case "Large":
                    return 4 * weight; // $4 * Weight for large parcels

                case "Heavy":
                    return 2 * weight; // $2 * Weight for heavy parcels

                case "Reject":
                    return weight; // $1 * Weight for rejected parcels (all weight exceeding 50kg)

                default:
                    throw new ArgumentException("Invalid classification");
            }
        }
    }
}