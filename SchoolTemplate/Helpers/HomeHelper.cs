using SchoolTemplate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTemplate.Helpers
{
    public class HomeHelper
    {
        public static string GenerateAcademicMemberFor(AcademicMemberModelView memberModelView)
        {
            string htmlAcademicMember = @"<div class='item'>
                                              <div class='edu2_faculty_des'>
                                                  <figure>
                                                      <img src='{0}' alt='' />
                                                      <figcaption>
                                                          <a href='/Teachers/Profile/{1}'>Ver Perfil</i></a>
                                                      </figcaption>
                                                  </figure>
                                                  <div class='edu2_faculty_des2'>
                                                      <h6><a href='#'>{2}</a></h6>
                                                      <strong>{3}</strong>                                                      
                                                  </div>
                                              </div>                 
                                          </div>";

            htmlAcademicMember = string.Format(htmlAcademicMember.ToString(),
                memberModelView.Picture, memberModelView.ID, memberModelView.Name, memberModelView.Function);

            return htmlAcademicMember;
        }
    }
}
