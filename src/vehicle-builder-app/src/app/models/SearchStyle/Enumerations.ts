export enum PriceState {
    actual = 'Actual',
    extimated = 'Extimated',
    unknown = 'Unknown',
}

export enum OrderAvailability {
    fleet = 'Fleet',
    retail = 'Retail'
}

export enum RoadSurface {
    concrete = 'Concrete',
    asphalt = 'Asphalt',
    hardGravel = 'HardGravel',
    looseGravel =  'LooseGravel',
    sand = 'Sand',
}

export enum UserDefinedBodyType {
    none ='None',
    dump = 'Dump',
    refuse = 'Refuse',
    van ='Van',
    flatbedRollback = 'FlatbedRollback',
    stake = 'Stake',
    tanker = 'Tanker',
    utility = 'Utility',
}

export enum MeasurementSystem {
    sae = 'SAE',
    metric = 'METRIC'
}