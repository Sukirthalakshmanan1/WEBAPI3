using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBAPI3.Models
{
    public class sub_mark
    {
        private int student_id;

        public int Id
        {
            get { return student_id; }
            set { student_id = value; }
        }

        private string student_name;

        public string Name
        {
            //20
            get { return student_name; }
            set
            {
                student_name = value;

            }
        }



        private int s;

        public int subject_marks
        {

            get { return s; }
            set
            {

                s = value;


            }
        }
    }
}