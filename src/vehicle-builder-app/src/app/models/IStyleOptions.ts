export interface ICabStyle {
    cabStyleId: number,
    cabStyleName: string
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


