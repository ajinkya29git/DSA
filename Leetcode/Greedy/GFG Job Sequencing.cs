using System;
using System.Collections.Generic;
using System.Linq;

public class JobSequencing
{
  public static int JobScheduling(List<(int JobId, int Deadline, int Profit)> jobs)
  {
    // Sort jobs by deadline (ascending), and then by profit (ascending) for equal deadline
    var sortedJobs = jobs
        .OrderBy(job => job.Deadline)
        .ThenBy(job => job.Profit)
        .ToList();

    int maxProfit = 0, n = sortedJobs.Count;
    
    //Edge case - only 1 job
    if(n==1)
      maxProfit += sortedJobs[0].Profit;
    
    else    //2 or more jobs
    {
      for(int i=1; i<n; i++)
      {
        if(sortedJobs[i].Deadline != sortedJobs[i-1].Deadline)
        {
          maxProfit += sortedJobs[i-1].Profit;
        }
      }
      
      //Edge case - Always take the last job  Why? think out
      /* 2 cases 1. last job deadline = (last-1) deadline
                  2. last job has different deadline
      */
      maxProfit += sortedJobs[n-1].Profit;
      
    }

    return maxProfit;
  }

  public static void Main()
  {
    // List of jobs (Job ID, Deadline, Profit)
    List<(int JobId, int Deadline, int Profit)> jobs = new List<(int, int, int)>
    {
      (1, 2, 100),
      (2, 1, 50),
      (3, 2, 10)
      //Expected O/P = 150
      
      // (1, 1, 40),
      // (2, 2, 30),
      // (3, 3, 20),
      // (4, 4, 10)
      //Expected O/P = 100
        
    };

    int maxProfit = JobScheduling(jobs);
    Console.WriteLine("Maximum Profit: " + maxProfit);
  }
}
