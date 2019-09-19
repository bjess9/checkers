CREATE SCHEMA IF NOT EXISTS tasmancoffeeconnection;

-- DROP SCHEMA tasmancoffeeconnection;

USE tasmancoffeeconnection;

CREATE TABLE `User` (
  userName varchar(255) NOT NULL, 
  password varchar(255) NOT NULL, 
  PRIMARY KEY (userName));
  
CREATE TABLE UserCurrentTutorialPage (
  FKuserName   varchar(255) NOT NULL, 
  CoffeePage int(10) NOT NULL, 
  RoastPage int(10) NOT NULL,
  PRIMARY KEY (FKuserName)
  );
CREATE TABLE competitionEntry (
  entryID        int(10) NOT NULL AUTO_INCREMENT, 
  classroomName varchar(255) NOT NULL, 
  schoolName    varchar(255) NOT NULL, 
  emailAddress  varchar(255) NOT NULL, 
  phoneNmbr     varchar(255) NOT NULL, 
  questionID    int(10) NOT NULL, 
  answerID      int(10) NOT NULL, 
  PRIMARY KEY (entryID));
CREATE TABLE Question (
  questionID   int(10) NOT NULL AUTO_INCREMENT, 
  questionText varchar(255) NOT NULL, 
  PRIMARY KEY (questionID));
CREATE TABLE Answer (
  answerID   int(10) NOT NULL AUTO_INCREMENT, 
  answerText varchar(255) NOT NULL, 
  isCorrect  char(1) NOT NULL, 
  PRIMARY KEY (answerID));
CREATE TABLE location (
  locationName int(10) NOT NULL AUTO_INCREMENT, 
  PRIMARY KEY (locationName));

CREATE TABLE questionAnswer (
  questionID     int(10) NOT NULL, 
  AnsweranswerID int(10) NOT NULL, 
  PRIMARY KEY (questionID, 
  AnsweranswerID));
  

create table `comments`(
    ID INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    Message VARCHAR(255),
    Name VARCHAR(255),
    `post_time` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
    Cafe VARCHAR(255) NOT NULL
);


ALTER TABLE usercurrenttutorialpage ADD CONSTRAINT FKuserName FOREIGN KEY (FKuserName) REFERENCES user (userName);
ALTER TABLE competitionEntry ADD CONSTRAINT FKcompititio421458 FOREIGN KEY (questionID, answerID) REFERENCES questionAnswer (questionID, AnsweranswerID);
ALTER TABLE questionAnswer ADD CONSTRAINT FKquestionAn559780 FOREIGN KEY (questionID) REFERENCES Question (questionID);
ALTER TABLE questionAnswer ADD CONSTRAINT FKquestionAn360828 FOREIGN KEY (AnsweranswerID) REFERENCES Answer (answerID);

-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    
-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    

insert into question (questionText) values ('What is the fastest type of coffee to make?');
insert into question (questionText) values ('What country is accredited for first giving us coffee?');
insert into question (questionText) values ('What language did the word "coffee" evolve from?');

insert into answer (answerText, isCorrect) values ('iced coffee', 0);
insert into answer (answerText, isCorrect) values ('plunger coffee', 0);
insert into answer (answerText, isCorrect) values ('instant coffee', 1);

insert into answer (answerText, isCorrect) values ('Ethiopia', 1);
insert into answer (answerText, isCorrect) values ('Australia Mate', 0);
insert into answer (answerText, isCorrect) values ('Russia', 0);

insert into answer (answerText, isCorrect) values ('Arabic', 1);
insert into answer (answerText, isCorrect) values ('Chinese', 0);
insert into answer (answerText, isCorrect) values ('Maori', 0);

insert into questionanswer (questionID, AnsweranswerID) values (1 , 1);
insert into questionanswer (questionID, AnsweranswerID) values (1 , 2);
insert into questionanswer (questionID, AnsweranswerID) values (1 , 3);

insert into questionanswer (questionID, AnsweranswerID) values (2 , 4);
insert into questionanswer (questionID, AnsweranswerID) values (2 , 5);
insert into questionanswer (questionID, AnsweranswerID) values (2 , 6);

insert into questionanswer (questionID, AnsweranswerID) values (3 , 7);
insert into questionanswer (questionID, AnsweranswerID) values (3 , 8);
insert into questionanswer (questionID, AnsweranswerID) values (3 , 9);


-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    
-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    

DELIMITER //
DROP PROCEDURE IF EXISTS 			insertCompetitionEntry//

CREATE PROCEDURE 					insertCompetitionEntry(
									prClassroomName 					varchar(255),
                                	prSchoolName						varchar(255),
                                	prEmailAddress						varchar(255),
                                	prPhoneNmbr							varchar(255),
                                	prQuestionID						int(10),
                                	prAnswerID							int(10))
									                       
	BEGIN
	
			INSERT INTO competitionEntry	
            (
				classroomName, schoolName, emailAddress, PhoneNmbr, questionID, answerID
			)
            VALUES 						
            (
				prClassroomName, prSchoolName, prEmailAddress, prPhoneNmbr, prQuestionID, prAnswerID                                
			);
            
END//

-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    
-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    

DELIMITER //
DROP PROCEDURE IF EXISTS 			grabCompetitionEntry//

CREATE PROCEDURE 					grabCompetitionEntry(
                                 	prEmailAddressIn 					varchar(255))

	BEGIN
										SELECT 	competitionentry.classroomName, 
												competitionentry.schoolName, 
												competitionentry.emailAddress, 
												competitionentry.phoneNmbr, 
												competitionentry.questionID, 
												competitionentry.answerID, 
												answer.answerText,
                                                question.questionText
                    
										FROM competitionentry
                                        
                                        JOIN questionanswer
                                        ON competitionentry.answerID = questionanswer.AnsweranswerID AND competitionentry.questionID = questionanswer.questionID      
                                        
                                        JOIN answer
                                        ON questionanswer.AnsweranswerID  = answer.answerID
                                        
                                        JOIN question
                                        ON questionanswer.questionID   = question.questionID
                                        
										WHERE emailAddress = prEmailAddressIn;
   
	END//

-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    
-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    

DELIMITER //
DROP PROCEDURE IF EXISTS 			grabRandomCompetitionQuestion//

CREATE PROCEDURE 					grabRandomCompetitionQuestion()
	BEGIN
    
				SELECT 	questionID 
                FROM 	question 
                ORDER BY RAND() LIMIT 1
				INTO 	@randID;
	
				SELECT 	question.questionID,question.questionText,
						answer.answerText,answer.answerID
                        
				FROM 	question
                
				JOIN 	questionanswer 
                ON 		questionanswer.questionID 	= question.questionID 
                
				JOIN 	answer 
                ON 		answer.answerID 			= questionanswer.AnswerAnswerID
				WHERE 	question.questionID 		= @randID;
     
END//

-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    
-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    

DELIMITER //
DROP PROCEDURE IF EXISTS 			login//

CREATE PROCEDURE 					login(
									IN prUserName varchar(255),
                                    IN prPassword varchar(255))
	BEGIN
    
    DECLARE lcNegativeResult int;
    
    SET lcNegativeResult = 1;
    
				IF EXISTS (SELECT * FROM `User` WHERE userName = prUserName AND password = prPassword)
                
                THEN
                
					SELECT * FROM `User` WHERE userName = prUserName AND password = prPassword;
                    
				ELSE
                
					SELECT lcNegativeResult;
                
				END IF;
END//

-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    
-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    

DELIMITER //
DROP PROCEDURE IF EXISTS 			register//

CREATE PROCEDURE 					register(
									IN prUserName varchar(255),
                                    IN prPassword varchar(255))
	BEGIN
    
    DECLARE lcNegativeResult int;
    
    SET lcNegativeResult = 1;
    
				IF NOT EXISTS (SELECT * FROM `user` WHERE userName = prUserName)
                
                THEN
                -- turn into transaction
                INSERT INTO `user`	
					(
						userName, password
					)
				VALUES 						
					(
						prUserName, prPassword                               
					);
                    
                    
                 
                 
				INSERT INTO `UserCurrentTutorialPage`	
					(
						FKuserName, CoffeePage, RoastPage
					)
				VALUES 						
					(
						prUserName, 1, 1                               
					);
                
                SELECT * FROM `user` WHERE userName = prUserName AND `password` = prPassword;
                
                ELSE
                
                SELECT lcNegativeResult;
                
				END IF;
END//

-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    
-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    

DELIMITER //
DROP PROCEDURE IF EXISTS 			updateUserTutorialProgress//

CREATE PROCEDURE 					updateUserTutorialProgress(
									IN prUserName 	varchar(255),
                                    IN prTutorial 	varchar(255),
                                    IN prTutNumber 	varchar(255))
	BEGIN
    
    IF (prTutorial = "Coffee")
    THEN
    
		UPDATE `UserCurrentTutorialPage`
		SET CoffeePage = prTutNumber
		WHERE FKuserName = prUserName;
        
    ELSE IF (prTutorial = "Roast")
    THEN
    
		UPDATE `UserCurrentTutorialPage`
		SET RoastPage = prTutNumber
		WHERE FKuserName = prUserName;
        
    END IF;
    END IF;
END//

-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    
-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    

DELIMITER //
DROP PROCEDURE IF EXISTS 			getUserTutorialProgress//

CREATE PROCEDURE 					getUserTutorialProgress(
									IN prUserName 	varchar(255),
                                    IN prTutorial 	varchar(255))
	BEGIN
    
    DECLARE lcNegativeResult int;
    
    SET lcNegativeResult = 1;
    
    IF (prTutorial = "Coffee")
    THEN
		IF EXISTS (SELECT CoffeePage FROM UserCurrentTutorialPage WHERE FKuserName = prUserName)
        THEN
        
		SELECT CoffeePage FROM UserCurrentTutorialPage WHERE FKuserName = prUserName;
        
        ELSE
        
        SELECT lcNegativeResult;
        
        END IF;
    
    ELSE IF (prTutorial = "Roast")
    THEN
		IF EXISTS (SELECT RoastPage FROM UserCurrentTutorialPage WHERE FKuserName = prUserName)
        THEN
        
		SELECT RoastPage FROM UserCurrentTutorialPage WHERE FKuserName = prUserName;
		
        ELSE
        
        SELECT lcNegativeResult;
        
        END IF;
        
    END IF;
    END IF;
    
END//

