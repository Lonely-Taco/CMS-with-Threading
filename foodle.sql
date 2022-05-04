CREATE TABLE amount_type
  (
     id   INT IDENTITY(1, 1) NOT NULL,
     name VARCHAR(50) NOT NULL,
     PRIMARY KEY(id)
  )

CREATE TABLE cuisine_label
  (
     id   INT IDENTITY(1, 1) NOT NULL,
     name VARCHAR(50),
     PRIMARY KEY(id)
  )

CREATE TABLE cuisine_label_filter
  (
     cuisine_label_id INT NOT NULL,
     filter_id        INT NOT NULL,
     PRIMARY KEY(cuisine_label_id, filter_id)
  )

CREATE TABLE diet
  (
     user_id          INT IDENTITY(1, 1) NOT NULL,
     diet_name        VARCHAR(50) NOT NULL,
     diet_description VARCHAR(5000) NOT NULL,
     PRIMARY KEY(user_id)
  )

CREATE TABLE diet_label
  (
     id   INT IDENTITY(1, 1) NOT NULL,
     name VARCHAR(50) NOT NULL,
     PRIMARY KEY(id)
  )

CREATE TABLE diet_label_filter
  (
     diet_label_id INT NOT NULL,
     filter_id     INT NOT NULL,
     PRIMARY KEY(diet_label_id, filter_id)
  )

CREATE TABLE diet_nutrients
  (
     id                 INT IDENTITY(1, 1) NOT NULL,
     diet_id            INT NOT NULL,
     nutrient_type_id   INT NOT NULL,
     recommended_amount FLOAT NOT NULL,
     PRIMARY KEY(id)
  )

CREATE TABLE dish_type
  (
     id   INT IDENTITY(1, 1) NOT NULL,
     name VARCHAR(50) NOT NULL,
     PRIMARY KEY(id)
  )

CREATE TABLE dish_type_filter
  (
     dish_type_id INT NOT NULL,
     filter_id    INT NOT NULL,
     PRIMARY KEY(dish_type_id, filter_id)
  )

CREATE TABLE filter
  (
     id          INT IDENTITY(1, 1) NOT NULL,
     user_id     INT NOT NULL,
     text_filter VARCHAR(50) NOT NULL,
     min_cal     INT NOT NULL,
     max_cal     INT NOT NULL,
     PRIMARY KEY(id)
  )

CREATE TABLE food_amount
  (
     id             INT IDENTITY(1, 1) NOT NULL,
     date           DATE NOT NULL,
     food_api_id    VARCHAR(50) NOT NULL,
     amount_type_id INT NOT NULL,
     amount_value   FLOAT NOT NULL,
     user_id        INT NOT NULL,
     PRIMARY KEY(id)
  )

CREATE TABLE health_label
  (
     id   INT IDENTITY(1, 1) NOT NULL,
     name VARCHAR(50) NOT NULL,
     PRIMARY KEY(id)
  )

CREATE TABLE health_label_filter
  (
     health_label_id INT NOT NULL,
     filter_id       INT NOT NULL,
     PRIMARY KEY(health_label_id, filter_id)
  )

CREATE TABLE meal_type
  (
     id   INT IDENTITY(1, 1) NOT NULL,
     name VARCHAR(50) NOT NULL,
     PRIMARY KEY(id)
  )

CREATE TABLE meal_type_filter
  (
     meal_type_id INT NOT NULL,
     filter_id    INT NOT NULL,
     PRIMARY KEY(meal_type_id, filter_id)
  )

CREATE TABLE nutrient_type
  (
     id   INT IDENTITY(1, 1) NOT NULL,
     name VARCHAR(50) NOT NULL,
     PRIMARY KEY(id)
  )

CREATE TABLE users
  (
     id               INT IDENTITY(1, 1) NOT NULL,
     window_color_hex VARCHAR(6),
     username         VARCHAR(50),
     PRIMARY KEY(id)
  )

CREATE TABLE workout
  (
     id          INT IDENTITY(1, 1) NOT NULL,
     user_id     INT NOT NULL,
     start_date  DATE NOT NULL,
     end_date    DATE NOT NULL,
     name        VARCHAR(50) NOT NULL,
     description TEXT NOT NULL,
     amount_of_calories_burned INT NOT NULL,
     PRIMARY KEY(id)
  )

CREATE TABLE workout_session
  (
     id              INT IDENTITY(1, 1) NOT NULL,
     workout_id      INT NOT NULL,
     start_time      DATETIME NOT NULL,
     end_time        DATETIME NOT NULL,
     calories_burned INT NOT NULL,
     PRIMARY KEY(id)
  )

ALTER TABLE cuisine_label_filter
  ADD CONSTRAINT fk_cuisine_label_filter_cuisine_label FOREIGN KEY (filter_id)
  REFERENCES cuisine_label(id)

ALTER TABLE cuisine_label_filter
  ADD CONSTRAINT fk_cuisine_label_filter_filter FOREIGN KEY (filter_id)
  REFERENCES filter(id)

ALTER TABLE diet
  ADD CONSTRAINT fk_diet_user FOREIGN KEY (user_id) REFERENCES users(id)

ALTER TABLE diet_label_filter
  ADD CONSTRAINT diet_label_filter_filter_id FOREIGN KEY (filter_id) REFERENCES
  filter(id)

ALTER TABLE diet_label_filter
  ADD CONSTRAINT fk_diet_label_filter_diet_label_id FOREIGN KEY (diet_label_id)
  REFERENCES diet_label(id)

ALTER TABLE diet_nutrients
  ADD CONSTRAINT fk_diet_nutrients_diet FOREIGN KEY (diet_id) REFERENCES diet(
  user_id)

ALTER TABLE diet_nutrients
  ADD CONSTRAINT fk_diet_nutrients_nutrient_type FOREIGN KEY (nutrient_type_id)
  REFERENCES nutrient_type(id)

ALTER TABLE dish_type_filter
  ADD CONSTRAINT fk_dish_type_filter_filter_id FOREIGN KEY(filter_id) REFERENCES
  filter(id)

ALTER TABLE dish_type_filter
  ADD CONSTRAINT fk_dish_type_filter_dish_type_id FOREIGN KEY(dish_type_id)
  REFERENCES dish_type(id)

ALTER TABLE filter
  ADD CONSTRAINT fk_filter_user FOREIGN KEY(user_id) REFERENCES users(id)

ALTER TABLE food_amount
  ADD CONSTRAINT fk_food_amount_amount_type_id FOREIGN KEY(amount_type_id)
  REFERENCES amount_type(id)

ALTER TABLE food_amount
  ADD CONSTRAINT fk_food_amount_user_id FOREIGN KEY(user_id) REFERENCES users(id
  )

ALTER TABLE health_label_filter
  ADD CONSTRAINT fk_health_label_filter_filter_id FOREIGN KEY(filter_id)
  REFERENCES filter(id)

ALTER TABLE health_label_filter
  ADD CONSTRAINT fk_health_label_filter_health_label_id FOREIGN KEY(
  health_label_id) REFERENCES health_label(id)

ALTER TABLE meal_type_filter
  ADD CONSTRAINT fk_meal_type_filter_filter FOREIGN KEY(filter_id) REFERENCES
  filter(id)

ALTER TABLE meal_type_filter
  ADD CONSTRAINT fk_meal_type_filter_meal_type FOREIGN KEY(meal_type_id)
  REFERENCES meal_type(id)

ALTER TABLE workout
  ADD CONSTRAINT fk_workout_user FOREIGN KEY(user_id) REFERENCES users(id)

ALTER TABLE workout_session
  ADD CONSTRAINT fk_workout_session_workout FOREIGN KEY(workout_id) REFERENCES
  workout(id) 