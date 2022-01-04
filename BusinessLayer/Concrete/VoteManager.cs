using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class VoteManager
    {
        GenericRepository<Vote> vote = new GenericRepository<Vote>();
        public List<Vote> GetVote() => vote.List();

        public Vote GetVoteID(int id)
        {
            return vote.Get(r => r.VoteID == id);
        }
        public void CreateVote(Vote v)
        {
            if (GetVote().Where(x => x.PostID == v.PostID && x.NickName == v.NickName).Count() > 0)
            {
                //İşlem yok
            }
            else
            {
                vote.Insert(v);
            }
        }
        public void DeleteVote(Vote v)
        {
            vote.Delete(v);
        }
    }
}
