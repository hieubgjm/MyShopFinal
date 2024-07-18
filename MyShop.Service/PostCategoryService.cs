using MyShop.Data.Infrastructure;
using MyShop.Data.Respositories;
using MyShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Service
{
    
        public interface IPostCategoryService
        {
        IEnumerable<PostCategory> Add(PostCategory postCategory);

            void Update(PostCategory postCategory);

            IEnumerable<PostCategory> Delete(int id);

            IEnumerable<PostCategory> GetAll();

            IEnumerable<PostCategory> GetAllByParentId(int parentId);

            IEnumerable<PostCategory> GetById(int id);

            void Save();
        }

        public class PostCategoryService : IPostCategoryService
        {
            private IPostCategoryRepository _postCategoryRepository;
            private IUnitOfWork _unitOfWork;

            public PostCategoryService(IPostCategoryRepository postCategoryRepository, IUnitOfWork unitOfWork)
            {
                _postCategoryRepository = postCategoryRepository;
                _unitOfWork = unitOfWork;
            }

            public IEnumerable<PostCategory> Add(PostCategory postCategory)
            {
            yield return _postCategoryRepository.Add(postCategory);
        }

            public IEnumerable<PostCategory> Delete(int id)
            {
                yield return _postCategoryRepository.Delete(id);
            }

            public IEnumerable<PostCategory> GetAll()
            {
                return _postCategoryRepository.GetAll();
            }

            public IEnumerable<PostCategory> GetAllByParentId(int parentId)
            {
                return _postCategoryRepository.GetMulti(x => x.Status && x.ParentID == parentId);
            }

            public IEnumerable<PostCategory> GetById(int id)
            {
            yield return _postCategoryRepository.GetSingleById(id);
            }

            public void Save()
            {
                _unitOfWork.Commit();
            }

            public void Update(PostCategory postCategory)
            {
                _postCategoryRepository.Update(postCategory);
            }

    }
    }

