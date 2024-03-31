export class User {
    userName = ''
    email = ''
    nacionality = ''
    password = ''
    role = ''
}

export interface IApiRegister {
    userName: string
    email: string
    nacionality: string
    password: string
    role: string
}

export interface IApiLogin {
    userName: string
    password: string
}

export interface IApiCreateAgency {
    name: string
    address: string
    fax: string
    electronicAddress: string
}

export interface IApiListAgency {
    id: number
    name: string
    address: string
    fax: string
    electronicAddress: string
}

export interface IApiCreateHotel {
    name: string
    category: string
    address: string
}

export interface IApiListHotel {
    id: number
    name: string
    category: string
    address: string
}

export interface IApiCreateHotelOffer {
    hotelId: number
    description: string
    price: number
}

export interface IApiListHotelOffer {
    description: string
    price: number
    hotelDto: number
}

export interface IApiCreateFacility {
    name: string
}

export interface IApiListFacility {
    name: string
}

export interface countriesJSON {
    name: string
}

export interface IApiCreateExcursion {
    id: number
    name: string
    capacity: number
    price: number
    arrivalDate: Date
    departureDate: Date
    arrivalPlace: string
    departurePlace: string
    guia: string
}