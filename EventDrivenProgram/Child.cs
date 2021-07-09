using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDrivenProgram
{
    //subject
    public delegate void JobStatusHanlder(string status);
    //Observable
    public class Child
    {
        string jobStatus="UnEmployeed";
        List<JobStatusHanlder> observers = new List<JobStatusHanlder>();
        public void GotNewJob()
        {
            jobStatus = "Employeed";
            //iterate 
            for(int i = 0; i < observers.Count; i++)
            {
              JobStatusHanlder eachObserver=  observers[i];
                eachObserver.Invoke(this.jobStatus);
            }

        }
        public void Add_Observer(JobStatusHanlder observer) {
            observers.Add(observer);
        }
        public void Remove_Observer(JobStatusHanlder observer) {

            observers.Remove(observer);
        }
    }
    /*
    public class Child
    {
       string jobStatus="UnEmployeed";
       public event  JobStatusHanlder OnJobStatusChanged;
        public void GotNewJob()
        {
            jobStatus = "Employeed";
            OnJobStatusChanged.Invoke(this.jobStatus);

        }
        
    }
    */
}
