﻿using System.Text;
using DiabloSharp.Extensions;

namespace DiabloSharp.Models
{
    public class AccountPeriodParagon : ModelBase<GameModeId>
    {
        public long Value { get; internal set; }

        protected override StringBuilder ToBuilder()
        {
            var builder = base.ToBuilder();
            builder.AppendProperty(nameof(Id), Id.ToString());
            builder.AppendProperty(nameof(Value), Value.ToString());
            return builder;
        }
    }
}