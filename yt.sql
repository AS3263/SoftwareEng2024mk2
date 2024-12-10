-- Create MembershipTypes Table
CREATE TABLE MembershipTypes (
    MembershipTypeID INT IDENTITY(1,1) PRIMARY KEY,
    TypeName NVARCHAR(50) NOT NULL,
    Description NVARCHAR(MAX)
);
CREATE TABLE Members (
    MemberID INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    IsAdmin BIT NOT NULL DEFAULT 0,
    Name NVARCHAR(100) NOT NULL,
    JoinDate DATETIME NOT NULL DEFAULT GETDATE(),
    MembershipTypeID INT NOT NULL,
    FOREIGN KEY (MembershipTypeID) REFERENCES MembershipTypes(MembershipTypeID)
);




-- Create Interests Table
CREATE TABLE Interests (
    InterestID INT IDENTITY(1,1) PRIMARY KEY,
    InterestName NVARCHAR(50) NOT NULL
);

CREATE TABLE MemberInterests (
    MemberInterestID INT IDENTITY(1,1) PRIMARY KEY,
    MemberID INT NOT NULL,
    InterestID INT NOT NULL,
    DateAssigned DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (MemberID) REFERENCES Members(MemberID),
    FOREIGN KEY (InterestID) REFERENCES Interests(InterestID)
);




-- Create DigitalContentModules Table
CREATE TABLE DigitalContentModules (
    ModuleID INT IDENTITY(1,1) PRIMARY KEY,
    ModuleName NVARCHAR(100) NOT NULL,
    Description NVARCHAR(MAX),
    ContentURL NVARCHAR(255)
);

CREATE TABLE MemberContentAccessed (
    AccessID INT IDENTITY(1,1) PRIMARY KEY,
    ModuleID INT NOT NULL,
    MemberID INT NOT NULL,
    AccessDate DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (ModuleID) REFERENCES DigitalContentModules(ModuleID),
    FOREIGN KEY (MemberID) REFERENCES Members(MemberID)
);



-- Create Benefits Table
CREATE TABLE Benefits (
    BenefitID INT IDENTITY(1,1) PRIMARY KEY,
    BenefitName NVARCHAR(100) NOT NULL,
    Description NVARCHAR(MAX),
    ApplicableMembershipTypeID INT NULL,
    FOREIGN KEY (ApplicableMembershipTypeID) REFERENCES MembershipTypes(MembershipTypeID)
);

CREATE TABLE MemberBenefits (
    MemberBenefitID INT IDENTITY(1,1) PRIMARY KEY,
    MemberID INT NOT NULL,
    BenefitID INT NOT NULL,
    UsageDate DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (MemberID) REFERENCES Members(MemberID),
    FOREIGN KEY (BenefitID) REFERENCES Benefits(BenefitID)
);


-- Insert Initial Data into Interests
INSERT INTO Interests (InterestName)
VALUES
('Caring'),
('Sharing'),
('Creating'),
('Experiencing'),
('Working');

-- Insert Initial Data into MembershipTypes
INSERT INTO MembershipTypes (TypeName, Description)
VALUES
('Community Membership', 'Basic membership with access to community events and resources.'),
('Community Membership with Key Access', 'Includes 24/7 access to the City Centre base.'),
('Creative Workspace Membership: Part Time', 'Part-time access to shared creative workspaces.');

-- Insert Initial Data into Benefits
INSERT INTO Benefits (BenefitName, Description, ApplicableMembershipTypeID)
VALUES
('Access to all Together Culture events and collaborative workshops', 'Benefit for members to participate in various events and workshops organized by Together Culture', 1),
('A welcoming City Centre space to connect, work, and relax', 'Access to a welcoming City Centre space', 1),
('Participation in the annual Citizens’ Studio', 'Opportunity to take part in the annual Citizens’ Studio', 1),
('A voice in decisions about Together Culture’s social enterprises', 'Have a say in the decision-making process regarding Together Culture’s social enterprises', 1),
('First edition Together Culture ‘Living Book’ for creative inspiration', 'Receive a first edition Together Culture ‘Living Book’', 1),
('Inclusive tickets to all events and collaborative workshops', 'Inclusive tickets to all Together Culture events and collaborative workshops', 2),
('24/7 key access to Together Culture’s City Centre base', 'Benefit of key access to the City Centre base 24/7', 2),
('A space to connect, work, and host gatherings with friends', 'Use the space for hosting gatherings with friends', 2),
('A Be Social Directory pack, including a Just People postcard and sticker pack', 'Receive a Be Social Directory pack with postcards and stickers', 2),
('24/7 access to a part-time studio or desk space, shared with a studio buddy', 'Benefit of shared access to a part-time studio or desk space', 3),
('Seasonal events and skills development sessions like the Turning Up and Butter Making Disco', 'Access to creative workshops, including seasonal events and skill development', 3),
('5 free guest passes to bring friends into Together Culture', 'Free guest passes to bring friends into Together Culture', 3),
('Access to the Fitzroy Street space with free tea, coffee, and WiFi', 'Access to the Fitzroy Street space with free amenities', 3);