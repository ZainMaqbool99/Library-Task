INSERT INTO Authors (AuthorName)
VALUES
('Ralph Kimball'),
('Shamkant B. Navathe'),
('Mark Lutz'),
('Walter Isaacson'),
('Jack Weatherford')


INSERT INTO Categories(CategoryName)
VALUES
('Computer & Tech'),
('History'),
('Business')


INSERT INTO SubCategories(SubCategoryName, CategoryId)
VALUES
('Database', '1'),
('Computer Science', '1'),
('Acient', '2'),
('Asian', '2'),
('Ecnomics', '3'),
('Industries & Professions', '3')


INSERT INTO BookDetails (BookName, SubCategoryId, AuthorId)
VALUES
('The Data Warehouse Toolkit', '1', '1'),
('Learning Python', '2', '3'),
('Genghiz Khan and the Making', '4', '5'),
('Fundamentals of Database', '1', '2'),
('Steve Jobs', '6', '4')