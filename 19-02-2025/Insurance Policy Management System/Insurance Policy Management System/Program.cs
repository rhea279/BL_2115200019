using System;
using System.Collections.Generic;
using System.Linq;

namespace InsurancePolicySystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // HashSet for unique policies
            HashSet<Policy> policySet = new HashSet<Policy>();

            // LinkedList to maintain order of insertion
            LinkedList<Policy> orderedPolicies = new LinkedList<Policy>();

            // SortedSet to maintain policies sorted by expiry date
            SortedSet<Policy> sortedPolicies = new SortedSet<Policy>(new ExpiryDateComparer());

            Console.Write("Enter number of policies: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter Policy Number: ");
                string policyNumber = Console.ReadLine();

                Console.Write("Enter Expiry Date (yyyy-MM-dd): ");
                DateTime expiryDate = DateTime.Parse(Console.ReadLine());

                Console.Write("Enter Coverage Type: ");
                string coverageType = Console.ReadLine();

                Policy policy = new Policy(policyNumber, expiryDate, coverageType);

                if (!policySet.Contains(policy))
                {
                    policySet.Add(policy);
                    orderedPolicies.AddLast(policy);
                    sortedPolicies.Add(policy);
                }
                else
                {
                    Console.WriteLine($"Duplicate Policy Detected: {policyNumber}");
                }
            }

            Console.WriteLine("\nAll Unique Policies:");
            DisplayPolicies(policySet);

            Console.WriteLine("\nPolicies Sorted by Expiry Date:");
            DisplayPolicies(sortedPolicies);

            Console.WriteLine("\nPolicies Expiring Soon (Next 30 Days):");
            DisplayPolicies(GetExpiringPolicies(sortedPolicies));

            Console.Write("\nEnter Coverage Type to Filter Policies: ");
            string coverageFilter = Console.ReadLine();
            DisplayPolicies(GetPoliciesByCoverage(policySet, coverageFilter));

            Console.WriteLine("\nDuplicate Policies:");
            DisplayDuplicatePolicies(policySet);
        }

        static void DisplayPolicies(IEnumerable<Policy> policies)
        {
            foreach (var policy in policies)
            {
                Console.WriteLine(policy);
            }
        }

        static IEnumerable<Policy> GetExpiringPolicies(SortedSet<Policy> policies)
        {
            DateTime today = DateTime.Today;
            return policies.Where(p => (p.ExpiryDate - today).TotalDays <= 30);
        }

        static IEnumerable<Policy> GetPoliciesByCoverage(HashSet<Policy> policies, string coverageType)
        {
            return policies.Where(p => p.CoverageType.Equals(coverageType, StringComparison.OrdinalIgnoreCase));
        }

        static void DisplayDuplicatePolicies(HashSet<Policy> policies)
        {
            var duplicates = policies.GroupBy(p => p.PolicyNumber)
                                     .Where(g => g.Count() > 1)
                                     .SelectMany(g => g);
            DisplayPolicies(duplicates);
        }
    }

    class Policy
    {
        public string PolicyNumber { get; }
        public DateTime ExpiryDate { get; }
        public string CoverageType { get; }

        public Policy(string policyNumber, DateTime expiryDate, string coverageType)
        {
            PolicyNumber = policyNumber;
            ExpiryDate = expiryDate;
            CoverageType = coverageType;
        }

        public override bool Equals(object obj)
        {
            return obj is Policy policy && PolicyNumber == policy.PolicyNumber;
        }

        public override int GetHashCode()
        {
            return PolicyNumber.GetHashCode();
        }

        public override string ToString()
        {
            return $"PolicyNumber: {PolicyNumber}, ExpiryDate: {ExpiryDate:yyyy-MM-dd}, CoverageType: {CoverageType}";
        }
    }

    class ExpiryDateComparer : IComparer<Policy>
    {
        public int Compare(Policy x, Policy y)
        {
            return x.ExpiryDate.CompareTo(y.ExpiryDate);
        }
    }
}
