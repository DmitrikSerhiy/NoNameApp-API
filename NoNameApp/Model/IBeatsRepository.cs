﻿using System;
using Model.Entities;

namespace Model {
    public interface IBeatsRepository {
        void UpdateBeats(Beat[] beats, Guid dmoId);
    }
}