import { ICargoItem } from "./ICargoItem";
import { MeasurementSystem, RoadSurface, UserDefinedBodyType } from "./Enumerations";

export interface IUserDefinedTechSpecs{
    roadSurfaceField: string,
    roadGradeField: number,
    occupantWeightField: number,
    bodyLengthField: number,
    bodyFrontalAreaField: number,
    bodyWeightField: number,
    cabToBodyDistanceField: number,
    trailerWeightField:number,
    cargoItemsField: ICargoItem[],
    bodyTypeField: string,
    measurementSystemField: string,
}

