using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeConsole.Data
{
    public enum SupervisoryLevel
    {
        Entry,              //0 if we had set Entry = 1, then it would count
        TeamMember,         //1     up from 1 instead of 0
        TeamLeader,         //2
        Supervisor,         //3
        DepartmentHead,     //4
        Owner               //5
    }
}

