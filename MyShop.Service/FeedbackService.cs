﻿using MyShop.Data.Infrastructure;
using MyShop.Data.Respositories;
using MyShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Service
{


        public interface IFeedbackService
        {
            Feedback Create(Feedback feedback);

            void Save();
        }

        public class FeedbackService : IFeedbackService
        {
            private IFeedbackRepository _feedbackRepository;
            private IUnitOfWork _unitOfWork;

            public FeedbackService(IFeedbackRepository feedbackRepository, IUnitOfWork unitOfWork)
            {
                _feedbackRepository = feedbackRepository;
                _unitOfWork = unitOfWork;
            }

            public Feedback Create(Feedback feedback)
            {
                return _feedbackRepository.Add(feedback);
            }

            public void Save()
            {
                _unitOfWork.Commit();
            }
        }

    }

