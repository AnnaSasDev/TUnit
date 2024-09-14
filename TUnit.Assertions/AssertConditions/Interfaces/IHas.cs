﻿using TUnit.Assertions.AssertConditions.Operators;

namespace TUnit.Assertions.AssertConditions.Interfaces;

public interface IHas<TActual, TAnd, TOr> : IVerbAction<TActual, TAnd, TOr>
    where TAnd : IAnd<TActual, TAnd, TOr>
    where TOr : IOr<TActual, TAnd, TOr>;