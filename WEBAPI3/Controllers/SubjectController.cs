﻿using BAL;
using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEBAPI3.Models;

namespace WEBAPI3.Controllers
{
    public class SubjectController : ApiController
    {

        Student_Helper obj = null;
        public SubjectController()
        {
            obj = new Student_Helper();
        }

         [Route("GetAllMarks")]
        public List<sub_mark> GetMarkList()
        {


            List<marks> empbal = new List<marks>();
            empbal = obj.BList();
            List<sub_mark> emps = new List<sub_mark>();
            foreach (var item in empbal)
            {
                //Employees emp = new Employees();
                emps.Add(new sub_mark{ Id = item.Id, Name = item.Name, subject_marks = item.subject_marks });
            }
            return emps;

        }

       




        // GET api/<controller>/5
        // [Route("~/FindE/{id}")]
        //  [Route("FindById/{id:int:min(1)}")]

        [Route("FindById/{id:int?}")]
        public sub_mark GetMarkByID(int id = 1)
        {
           marks empbal = new marks();
            empbal = obj.search(id);
            sub_mark emp = new sub_mark();
            //emp.Id = empbal.Id;
            emp.Id = id;
            emp.Name = empbal.Name;
            emp.subject_marks = empbal.subject_marks;

            return emp;
            
        }

        // POST api/<controller>
        public HttpResponseMessage PostMarks([FromBody] sub_mark empdata)
        {
            marks empbal = new marks();
            empbal.Id= empdata.Id;
            empbal.Name = empdata.Name;
            empbal.subject_marks = empdata.subject_marks;


            bool ans = obj.AddE(empbal);
            if (ans)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }

        }

        // PUT api/<controller>/5
        public HttpResponseMessage PutMarks([FromBody] sub_mark empdata)
        {

            marks empbal = new marks();
            empbal.Id= empdata.Id;
            empbal.Name = empdata.Name;
            empbal.subject_marks = empdata.subject_marks;



            bool ans = obj.Edit(empbal);
            if (ans)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }
        }

        // DELETE api/<controller>/5
        public HttpResponseMessage DeleteProduct(int id)
        {
            bool ans = obj.remove(id);
            if (ans)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }

        }

      
    }
}