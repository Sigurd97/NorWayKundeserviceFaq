/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { UserQuestionService } from './user-question.service';

describe('Service: UserQuestion', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [UserQuestionService]
    });
  });

  it('should ...', inject([UserQuestionService], (service: UserQuestionService) => {
    expect(service).toBeTruthy();
  }));
});
