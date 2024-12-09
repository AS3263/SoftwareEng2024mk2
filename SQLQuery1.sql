-- Insert into Users table
--INSERT INTO Users (Username, PasswordHash, Email, IsAdmin, DateCreated)VALUES ('johndoe','ef92b778bafe771e89245b89ecbc5eb89a41f4e587a0d0cce3e1a5ad95d1d3ad', 'johndoe@example.com', 0, GETDATE());

-- Assuming the UserID for this user is 1 (use the actual UserID returned)
-- Insert into Members table
INSERT INTO Users(Username, PasswordHash, Email, IsAdmin, DateCreated, FirstName, LastName, JoinDate, MembershipTypeID)
VALUES 
('johndoe','ef92b778bafe771e89245b89ecbc5eb89a41f4e587a0d0cce3e1a5ad95d1d3ad', 'johndoe@example.com', 0, GETDATE(), 'John', 'Doe', GETDATE(), 2);

-- Assuming MembershipTypeID 2 corresponds to "Community Membership with Key Access"
-- Link the member to interests
INSERT INTO MemberInterests (UserID, InterestID, DateAssigned)
VALUES 
(1, 3, GETDATE()); -- Assuming InterestID 3 corresponds to "Creating"