using System.Collections.Generic;

namespace WorkForce
{
    public class JobList : List<Job>
    {
        public void OnJobDone(object sender, JobEventArgs e)
        {
            this.Remove(e.Job);
        }
    }
}