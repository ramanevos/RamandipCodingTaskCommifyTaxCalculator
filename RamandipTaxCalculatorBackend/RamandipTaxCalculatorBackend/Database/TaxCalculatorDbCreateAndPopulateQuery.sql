CREATE TABLE TaxBands
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    LowerLimit DECIMAL(18, 2) NOT NULL,
    UpperLimit DECIMAL(18, 2) NOT NULL,
    TaxRate INT NOT NULL
);

INSERT INTO TaxBands (LowerLimit, UpperLimit, TaxRate)
VALUES
(0, 5000, 0),         -- Tax Band A
(5000, 20000, 20),    -- Tax Band B
(20000, 999999999, 40); -- Tax Band C (no upper limit)
