using Repo.Models;
using Repo.Models.Partial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.IRepo
{
    public interface IGetForView
    {
        IEnumerable<AdType> Types();

        IEnumerable<AdCategory> Categories();

        List<AdModel> Ads();

        AdModel AdViewModel();

        AdModel AdByUserId(string userId);

        bool CheckAdByUserId(string userId);
    }
}
