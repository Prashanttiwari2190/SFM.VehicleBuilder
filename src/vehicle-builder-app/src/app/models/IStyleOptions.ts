export interface ICabStyle {
    bodyTypeId: number,
    bodyTypeName: string,
    primary: boolean
}

export interface IExteriorColor {
    colorId: string,
    colorName: string,
    colorCode: string
}


export interface IStyleOptions {
    cabStyle: Array<ICabStyle> ;
    exteriorColor: Array<IExteriorColor>
}


