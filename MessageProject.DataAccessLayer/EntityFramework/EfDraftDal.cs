using MessageProject.DataAccessLayer.Abstract;
using MessageProject.DataAccessLayer.Repository;
using MessageProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageProject.DataAccessLayer.EntityFramework
{
    public class EfDraftDal : GenericRepository<Draft>, IDraftDal
    {
    }
}
