﻿namespace CoreLayer.Utilities.Results
{
    public class ErrorResult : Result
    {
        public ErrorResult(string message) : base(false)
        {
        }

        public ErrorResult() : base(false)
        {

        }
    }
}