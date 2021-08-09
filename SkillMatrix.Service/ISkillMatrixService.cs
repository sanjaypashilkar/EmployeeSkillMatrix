﻿using SkillMatrix.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillMatrix.Service
{
    public interface ISkillMatrixService
    {
        List<vwImportAndSave> GetUploadedSkillMatrix(string fileName);
        void SaveSkillMatrix(string fileName, string year, string quarter);
    }
}
