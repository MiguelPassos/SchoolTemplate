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
                                                          <a href='/Account/Profile/{1}'>Ver Perfil</i></a>
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

        public static string GenerateEventInfoFor(EventViewModel eventModelView, int index)
        {
            #region Default Patterns

            string thumb = @"<div class='col-md-6 col-sm-6 thumb'>
                                <figure>
                                    <img src='{IMAGE}' alt=''>
                                </figure>
                             </div>";

            string evtInfo = @"<div class='col-md-6 col-sm-6'>
                                  <div class='edu2_event_des{ALIGN}'>
                                      <h4>{MONTH}</h4>
                                      <p>{DESC}</p>
                                      <ul class='post-option'>
                                          <li>Postado por<a href='#'>&nbspAdmin</a></li>
                                          <li>{DATE}</li>
                                      </ul>
                                      <a href='/Calendar/Event/{ID}' class='readmore'>leia mais<i class='fa fa-long-arrow-alt-right'></i></a>
                                      <span>{DAY}</span>
                                  </div>
                               </div>";

            #endregion

            evtInfo = evtInfo.Replace("{MONTH}", eventModelView.EventDate.ToString("MMM"))
                                 .Replace("{DESC}", eventModelView.Description)
                                 .Replace("{DATE}", eventModelView.CreationDate.ToString("dd/MM/yyyy"))
                                 .Replace("{DAY}", eventModelView.EventDate.ToString("dd"))
                                 .Replace("{ID}", eventModelView.ID.ToString());

            thumb = thumb.Replace("{IMAGE}", eventModelView.UriImage);

            if (index%2 == 0)   //Posicionado a esquerda
                return string.Concat(evtInfo.Replace("{ALIGN}", ""), thumb);
            else                //Posicionado a direita
                return string.Concat(thumb, evtInfo.Replace("{ALIGN}", " text-right"));
        }
    }
}
