# HUBBE RESERVATION API

### Description 
This project is a exame for a job aquisition at HUBBE. Its a API RESTful which make reservations to a restaurant. The operator will be able to reserv, consult and delete a reservation.

### Table of contents
============


   * [Installation](#Installation)
   * [Usage](#Usage)
        * [Register](#Register)
        * [ReservationList](#ReservationList)
        * [ReservationListByDate](#ReservationListByDate)
        * [ReservationListByTable](#ReservationListByTable)
        * [UpComingReservationList](#UpComingReservationList)
        * [GetByDate](#GetByDate)
        * [ReservCancelation](#ReservCancelation)
        * [ReservCancelationById](#ReservCancelationById)


Installation
============

Usage
============
Beçpw are all methods for this API

Register
============
On this method the operator will be able to register a new reservation. Fields: Registration Date, Registration Time, Table Number, Number of People, Description

ReservationList
============
On this method the operator will be able to get all reservations in the database. Fields: No filed is required

ReservationListByDate
============
On this method the operator will be able to get a list of reservations by date. Fields: Registration Date, Registration Time

ReservationListByTable
============
On this method the operator will be able to get a list of reservations by the number of the Table. Fields: Table number

UpComingReservationList
============
On this method the operator will be able to get all the upcoming reservations in the database. Fields: No filed is required

GetByDate
============
On this method the operator will be able to check if there are reservation in a specific date. Different from the ReservationListByDate Method, the GetByDate method will return a list of tables available for that time and date. Fields: Registration Date, Registration Time

ReservCancelation
============
On this method the operator will be able to delete a reservations by date and by table number. Fields: Registration Date, Registration Time, Table number

ReservCancelationById
============
On this method the operator will be able to delete a reservations by a reservation ID. Fields: Reservation ID
