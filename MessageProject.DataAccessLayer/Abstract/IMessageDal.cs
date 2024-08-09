using MessageProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageProject.DataAccessLayer.Abstravt
{
    public interface IMessageDal: IGenericDal<Message>
    {
    }
}
