DataBase scripts:-
CREATE TABLE ChannelList (
    channel_id INT PRIMARY KEY,
    channel_name VARCHAR(50) NOT NULL,
    is_active BOOLEAN DEFAULT TRUE
);

CREATE TABLE UserIntegratedChannels (
    user_id INT,
    channel_id INT,
    is_permitted BOOLEAN DEFAULT TRUE,
    FOREIGN KEY (channel_id) REFERENCES ChannelList(channel_id)
);

INSERT INTO ChannelList (channel_id, channel_name) VALUES 
(1, 'Shopify'),
(2, 'Woo-commerce'),
(3, 'Amazon');

INSERT INTO UserIntegratedChannels (user_id, channel_id) VALUES 
(1, 1), 
(1, 2),
(2, 3);


 
Just change the connection strings and then it works fine
